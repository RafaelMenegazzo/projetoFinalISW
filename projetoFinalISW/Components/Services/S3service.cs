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
                    "A capa deve estar no formato JPG, PNG ou WEBP.");
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
            if (string.IsNullOrWhiteSpace(chave))
            {
                throw new ArgumentException(
                    "A chave da imagem não foi informada.");
            }

            var requisicao = new GetPreSignedUrlRequest
            {
                BucketName = ObterNomeBucket(),
                Key = chave.Trim(),
                Expires = DateTime.UtcNow.AddHours(1),
                Verb = HttpVerb.GET
            };

            return _s3.GetPreSignedURL(requisicao);
        }

        private string ObterNomeBucket()
        {
            string? bucket =
                _configuration["AWS:BucketCapas"];

            if (string.IsNullOrWhiteSpace(bucket))
            {
                throw new InvalidOperationException(
                    "O nome do bucket não foi configurado em AWS:BucketCapas.");
            }

            bucket = bucket.Trim();

            if (bucket.StartsWith("s3://",
                    StringComparison.OrdinalIgnoreCase) ||
                bucket.StartsWith("http://",
                    StringComparison.OrdinalIgnoreCase) ||
                bucket.StartsWith("https://",
                    StringComparison.OrdinalIgnoreCase) ||
                bucket.Contains('/'))
            {
                throw new InvalidOperationException(
                    $"O valor '{bucket}' não é um nome de bucket válido. " +
                    "Informe apenas: biblioteca-isw-capas-rafael");
            }

            return bucket;
        }
    }
}