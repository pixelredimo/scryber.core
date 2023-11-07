﻿using System;
using Scryber.Components;
using Scryber.Drawing;
using Scryber.PDF.Native;
using Scryber.Styles;
using Scryber.PDF;
using Scryber.PDF.Graphics;

namespace Scryber.Svg.Components
{
    public abstract class SVGShape : SVGBase, IGraphicPathComponent, IPDFRenderComponent
    {

        public SVGShape(ObjectType type)
            : base(type)
        {
        }

        private GraphicsPath _path;

        protected GraphicsPath Path
        {
            get { return _path; }
            set { _path = value; }
        }

        GraphicsPath IGraphicPathComponent.Path
        {
            get { return this.Path; }
            set { this.Path = value; }
        }


        protected abstract GraphicsPath CreatePath(Size available, Style fullstyle);

        GraphicsPath IGraphicPathComponent.CreatePath(Size available, Style fullstyle)
        {
            return this.CreatePath(available, fullstyle);
        }

        public PDFObjectRef OutputToPDF(PDFRenderContext context, PDFWriter writer)
        {
            Style fullstyle = context.FullStyle;
            if (null == fullstyle)
                throw new ArgumentNullException("context.FullStyle");

            var graphics = context.Graphics;
            if (null == graphics)
                throw new ArgumentNullException("context.Graphics");

            if (null != this.Path)
            {
                var transform = fullstyle.GetValue(StyleKeys.TransformOperationKey, null);
                if(transform != null)
                {
                    var matrix = transform.GetMatrix(MatrixOrder.Append);
                    graphics.SaveGraphicsState();
                    graphics.SetTransformationMatrix(matrix, false, true);
                }

                PDFBrush brush = fullstyle.CreateFillBrush();
                PDFPen pen = fullstyle.CreateStrokePen();

                if (null != pen && null != brush)
                    graphics.FillAndStrokePath(brush, pen, context.Offset, this.Path);

                else if (null != brush)
                    graphics.FillPath(brush, context.Offset, this.Path);

                else if (null != pen)
                    graphics.DrawPath(pen, context.Offset, this.Path);

                if (null != transform)
                    graphics.RestoreGraphicsState();
            }
            return null;
        }

        protected override void OnPreLayout(LayoutContext context)
        {
            this.UpdateShapeBounds(context);
            base.OnPreLayout(context);
        }

        protected virtual void UpdateShapeBounds(ContextBase context)
        {
            var bounds = this.GetBounds();
            if (bounds != Rect.Empty)
            {
                this.X = bounds.X;
                this.Y = bounds.Y;
                this.Width = bounds.Width;
                this.Height = bounds.Height;
            }
        }



        protected virtual Rect GetBounds()
        {
            return Rect.Empty;
        }
    }
}
