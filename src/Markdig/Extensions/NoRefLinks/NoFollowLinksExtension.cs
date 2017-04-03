// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.

using Markdig.Renderers;
using Markdig.Renderers.Html.Inlines;

namespace Markdig.Extensions.NoRefLinks
{
    /// <summary>
    /// Extension to automatically render rel=nofollow to all links in an HTML output.
    /// </summary>
    public class NoFollowLinksExtension : IMarkdownExtension
    {
        public NoFollowLinksExtension() : this(new LinkRelsOptions())
        {
        }

        public NoFollowLinksExtension(LinkRelsOptions options)
        {
            Options = options ?? new LinkRelsOptions();
        }

        public LinkRelsOptions Options { get; }


        public void Setup(MarkdownPipelineBuilder pipeline)
        {
        }

        public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
        {
            var linkRenderer = renderer.ObjectRenderers.Find<LinkInlineRenderer>();
            if (linkRenderer != null)
            {
                linkRenderer.AutoRelNoFollow = Options.AutoRelNoFollow;
                linkRenderer.AutoRelNoOpener = Options.AutoRelNoOpener;
                linkRenderer.AutoRelNoReferrer = Options.AutoRelNoReferrer;
            }

            var autolinkRenderer = renderer.ObjectRenderers.Find<AutolinkInlineRenderer>();
            if (autolinkRenderer != null)
            {
                autolinkRenderer.AutoRelNoFollow = Options.AutoRelNoFollow;
                autolinkRenderer.AutoRelNoOpener = Options.AutoRelNoOpener;
                autolinkRenderer.AutoRelNoReferrer = Options.AutoRelNoReferrer;
            }
        }
    }
}
