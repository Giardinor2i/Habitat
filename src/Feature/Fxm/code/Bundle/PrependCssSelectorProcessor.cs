using Sitecore.Diagnostics;
using System.Web.Optimization;
using Sitecore.FXM.Pipelines.Bundle;

namespace Sitecore.Feature.Fxm.Bundle
{
    public class PrependCssSelectorProcessor : IBundleProcessor, IBundleProcessor<IBundleGeneratorArgs>
    {
        public void Process(IBundleGeneratorArgs args)
        {
            Assert.ArgumentNotNull((object)args, "args");
            var transform = new PrependCssSelectorTransform();
            args.Bundle.Transforms.Add(transform);
        }
    }
}