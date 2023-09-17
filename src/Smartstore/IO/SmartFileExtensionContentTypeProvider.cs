using Microsoft.AspNetCore.StaticFiles;

namespace Smartstore.IO
{
    public class SmartFileExtensionContentTypeProvider : FileExtensionContentTypeProvider
    {
        public SmartFileExtensionContentTypeProvider()
            : base()
        {

            base.Mappings[".vue"] = "text/html";
            // TODO: (core) Add more file extensions to FileExtensionContentTypeProvider (?)
        }
    }
}
