using PrivateProxy;
using Projects.M3eEmbedding.Normalizers;

namespace Projects.M3eEmbedding.Test.Proxy;

[GeneratePrivateProxy(typeof(BertNormalizer))]
public partial struct BertNormalizerProxy;
