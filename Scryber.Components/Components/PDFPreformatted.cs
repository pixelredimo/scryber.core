﻿/*  Copyright 2012 PerceiveIT Limited
 *  This file is part of the Scryber library.
 *
 *  You can redistribute Scryber and/or modify 
 *  it under the terms of the GNU Lesser General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 * 
 *  Scryber is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU Lesser General Public License for more details.
 * 
 *  You should have received a copy of the GNU Lesser General Public License
 *  along with Scryber source code in the COPYING.txt file.  If not, see <http://www.gnu.org/licenses/>.
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scryber.Components
{
    /// <summary>
    /// Defines a pre-formatted block of text. Lines and spaces in the source are preservered.
    /// </summary>
    [PDFParsableComponent("Pre")]
    public class PDFPreformatted : PDFPanel
    {

        /// <summary>
        /// Default collection of contents
        /// </summary>
        [PDFElement()]
        [PDFArray(typeof(PDFComponent))]
        public override PDFComponentList Contents
        {
            get
            {
                return base.Contents;
            }
        }

        public PDFPreformatted()
            : this(PDFObjectTypes.Preformatted)
        {
        }

        public PDFPreformatted(PDFObjectType type)
            : base(type)
        {
            
        }


        protected override Styles.PDFStyle GetBaseStyle()
        {
            Styles.PDFStyle style = base.GetBaseStyle();
            style.Font.FontFamily = PDFFonts.Courier.Family;
            style.Text.WrapText = Scryber.Text.WordWrap.NoWrap;
            style.Text.PreserveWhitespace = true;
            style.Position.PositionMode = Drawing.PositionMode.Block;
            style.Overflow.Split = Drawing.OverflowSplit.Never;
            return style;
        }
    }
}