﻿using System;
using System.Diagnostics.Tracing;
using Scryber.Styles;
using Scryber.Components;

namespace Scryber.Html.Components
{
    //TODO: make this a lazy load with content dynamically parsed
    
    [PDFParsableComponent("iframeContent")]
    [PDFRemoteParsableComponent("iframe", SourceAttribute = "src")]
    public class HTMLiFrame : Div
    {

        [PDFAttribute("class")]
        public override string StyleClass
        {
            get => base.StyleClass;
            set => base.StyleClass = value;
        }

        [PDFAttribute("style")]
        public override Style Style
        {
            get => base.Style;
            set => base.Style = value;
        }


        /// <summary>
        /// Global Html hidden attribute used with xhtml as hidden='hidden'
        /// </summary>
        [PDFAttribute("hidden")]
        public string Hidden
        {
            get
            {
                if (this.Visible)
                    return string.Empty;
                else
                    return "hidden";
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value != "hidden")
                    this.Visible = true;
                else
                    this.Visible = false;
            }
        }

        [PDFAttribute("title")]
        public override string OutlineTitle
        {
            get => base.OutlineTitle;
            set => base.OutlineTitle = value;
        }

        [PDFElement("")]
        [PDFArray(typeof(Component))]
        public override ComponentList Contents
        {
            get { return base.Contents; }
        }

        [PDFAttribute("data-passthrough")]
        public bool Passthrough
        {
            get;
            set;
        }

        public HTMLiFrame() : this(HTMLObjectTypes.IFrame)
        {
        }

        protected HTMLiFrame(ObjectType type): base(type)
        {
            this.Passthrough = true;
        }


        public override Style GetAppliedStyle(Component forComponent, Style baseStyle)
        {
            if (!Passthrough)
            {
                //TODO: Check the styles and contents of the remote parsed components
                return new Style();
            }
            else
                return base.GetAppliedStyle(forComponent, baseStyle);
        }
    }
}
