using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using ZEMIC.ScrumBoard.API.Filter;
using ZEMIC.ScrumBoard.Logic;

namespace ZEMIC.ScrumBoard.API.Controllers.API
{
    public class MediasController : BaseApiController
    {
        private readonly IMediaLogic _mediaLogic;

        public MediasController(IMediaLogic mediaLogic)
        {
            _mediaLogic = mediaLogic;
        }

        [Route("api/medias/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(Guid id)
        {
            return Execute(() =>
            {
                var mediaViewModel = _mediaLogic.GetById(id);
                var response = new HttpResponseMessage();
                var media = _mediaLogic.GetById(id);
                response.Content = new StreamContent(media.Buffer);
                response.Content.Headers.ContentType = new MediaTypeHeaderValue(mediaViewModel.ContentType);
                response.StatusCode = HttpStatusCode.OK;
                response.Content.Headers.ContentLength = media.Buffer.Length;

                return response;
            });
        }
        [Route("api/medias")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            try
            {
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                var file = provider.Contents.FirstOrDefault(x => x.Headers.ContentType != null);
                var buffer = await file.ReadAsByteArrayAsync();
                var contentType = file.Headers.ContentType.ToString();
                var name = file.Headers.ContentDisposition.FileName.Replace("\"", "");

                var mediaId = _mediaLogic.Create(buffer, contentType, name);

                var response = Request.CreateResponse(HttpStatusCode.OK, mediaId.ToString());

                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        [Route("api/medias/{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            Execute(() =>
            {
                _mediaLogic.Delete(id);
            });
        }
    }
}