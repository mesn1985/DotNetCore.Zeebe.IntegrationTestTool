using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ZeebeBscProj.API.Extensions
{
    public static class IFormFileExtensions
    {
        public async static Task<Byte[]> ToByteArrayAsync(this IFormFile file)
        {
            byte[] fileBytes;

          return  await Task.Run(() =>
                     {
                         using (var ms = new MemoryStream())
                         {
                              file.CopyTo(ms);
                              fileBytes = ms.ToArray();
                              return fileBytes;
                         }
                     });
        }


    }
}
