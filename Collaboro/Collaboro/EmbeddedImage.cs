using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Collaboro.MarkupExtensions {
    class EmbeddedImage : IMarkupExtension {
        public string ResourceId { get; set; }

        /// <summary>
        /// Returns an image if resource identifier is valid
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns>Requested Image</returns>
        public object ProvideValue(IServiceProvider serviceProvider) {
            if (String.IsNullOrWhiteSpace(ResourceId)) {
                return null;
            }
            return ImageSource.FromResource(ResourceId);
        }
    }
}
