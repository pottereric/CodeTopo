﻿//------------------------------------------------------------------------------
// <copyright file="ClassTopoFactory.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace CodeTopo
{
    /// <summary>
    /// Export a <see cref="IWpfTextViewMarginProvider"/>, which returns an instance of the margin for the editor to use.
    /// </summary>
    [Export(typeof(IWpfTextViewMarginProvider))]
    [Name(ClassTopo.MarginName)]
    [Order(After = PredefinedMarginNames.VerticalScrollBar)]  // Ensure that the margin occurs below the horizontal scrollbar
    [MarginContainer(PredefinedMarginNames.Right)]             // Set the container to the bottom of the editor window
    //[Order(After = PredefinedMarginNames.Spacer, Before = PredefinedMarginNames.Outlining)]
    //[MarginContainer(PredefinedMarginNames.LeftSelection)]
    [ContentType("CSharp")]                                       // Show this margin for all text-based types
    [TextViewRole(PredefinedTextViewRoles.Interactive)]
    internal sealed class ClassTopoFactory : IWpfTextViewMarginProvider
    {
        //[ImportingConstructor]
        //public ClassTopoFactory(IContentTypeRegistryService contentTypeRegistryService)
        //{
        //    this.csharpContentType = contentTypeRegistryService.GetContentType("CSharp");

        //}

        #region IWpfTextViewMarginProvider

        /// <summary>
        /// Creates an <see cref="IWpfTextViewMargin"/> for the given <see cref="IWpfTextViewHost"/>.
        /// </summary>
        /// <param name="wpfTextViewHost">The <see cref="IWpfTextViewHost"/> for which to create the <see cref="IWpfTextViewMargin"/>.</param>
        /// <param name="marginContainer">The margin that will contain the newly-created margin.</param>
        /// <returns>The <see cref="IWpfTextViewMargin"/>.
        /// The value may be null if this <see cref="IWpfTextViewMarginProvider"/> does not participate for this context.
        /// </returns>
        public IWpfTextViewMargin CreateMargin(IWpfTextViewHost wpfTextViewHost, IWpfTextViewMargin marginContainer)
        {
            return new ClassTopo(wpfTextViewHost.TextView);
        }

        #endregion IWpfTextViewMarginProvider
    }
}