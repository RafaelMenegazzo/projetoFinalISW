using Amazon.S3;
using Amazon.S3.Model;

namespace projetoFinalISW.Components.Services
{
    public class S3Service
    {
        private readonly IAmazonS3 _s3;
        private readonly IConfiguration _configuration;

        private static readonly string[] TiposPermitidos =
        {
            "image/jpeg",
            "image/png",
            "image/webp"
        };

        public S3Service(
            IAmazonS3 s3,
            IConfiguration configuration)
        {
            _s3 = s3;
            _configuration = configuration;
        }

        public async Task<string> EnviarCapaAsync(
            Stream arquivo,
            string nomeOriginal,
            string tipoConteudo)
        {
            if (!TiposPermitidos.Contains(tipoConteudo))
            {
                throw new InvalidOperationException(
                    "A capa deve ser JPG, PNG ou WEBP.");
            }

            string bucket = ObterNomeBucket();

            string extensao = Path
                .GetExtension(nomeOriginal)
                .ToLowerInvariant();

            string chave =
                $"capas/{Guid.NewGuid():N}{extensao}";

            var requisicao = new PutObjectRequest
            {
                BucketName = bucket,
                Key = chave,
                InputStream = arquivo,
                ContentType = tipoConteudo
            };

            await _s3.PutObjectAsync(requisicao);

            return chave;
        }

        public string ObterUrlTemporaria(string chave)
        {
            var requisicao = new GetPreSignedUrlRequest
            {
                BucketName = ObterNomeBucket(),
                Key = chave,
                Expires = DateTime.UtcNow.AddHours(1),
                Verb = HttpVerb.GET
            };

            return _s3.GetPreSignedURL(requisicao);
        }

        private string ObterNomeBucket()
        {
            return _configuration["AWS:BucketCapas"]
                ?? throw new InvalidOperationException(
                    "O nome do bucket S3 não foi configurado.");
        }
    }
}