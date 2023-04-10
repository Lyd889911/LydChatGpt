using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChatGpt.WebApi.Middlewares
{
    public class ResponseMiddleware
    {
        private readonly RequestDelegate _next;
        public ResponseMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //读取请求体
            context.Request.EnableBuffering();
            var request = context.Request;
            request.Body.Position = 0;
            using StreamReader sr = new StreamReader(request.Body);
            string body = await sr.ReadToEndAsync();
            //Console.WriteLine($"Response Body: {body}");
            request.Body.Position = 0;


            //读取响应体
            var originalResponseStream = context.Response.Body;
            using var ms = new MemoryStream();
            context.Response.Body = ms;
            string responseContent = null;
            try
            {
                await _next(context);
                ms.Position = 0;
                var responseReader = new StreamReader(ms);
                responseContent = await responseReader.ReadToEndAsync();

                //if(!string.IsNullOrEmpty(responseContent))
                //    responseContent = JsonConvert.SerializeObject(new ResultDto(200, null, JsonConvert.DeserializeObject(responseContent)));
                if (string.IsNullOrEmpty(responseContent))
                    responseContent = JsonConvert.SerializeObject(new ResultDto(200, "操作成功", null));
                else
                {
                    responseContent = JsonConvert.SerializeObject(new ResultDto(200, null, JsonConvert.DeserializeObject(responseContent)));
                }


            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 200;
                Console.WriteLine("报错误了哦");
                responseContent = JsonConvert.SerializeObject(new ResultDto(520, ex.Message, null));
            }

            #region 设置响应码，各种asp.net内置的响应码统一为200,t统一响应格式
            switch (context.Response.StatusCode)
            {
                case 401:
                    context.Response.StatusCode = 200;
                    responseContent = JsonConvert.SerializeObject(new ResultDto(401, "没有登录", null));
                    break;
                case 403:
                    context.Response.StatusCode = 200;
                    responseContent = JsonConvert.SerializeObject(new ResultDto(401, "没有权限", null));
                    break;
                case 400:
                    context.Response.StatusCode = 200;
                    responseContent = JsonConvert.SerializeObject(new ResultDto(400, "请求错误", null));
                    break;
                case 405:
                    context.Response.StatusCode = 200;
                    responseContent = JsonConvert.SerializeObject(new ResultDto(405, "请求方法不对", null));
                    break;
            }
            #endregion

            ms.Position = 0;
            await context.Response.WriteAsync(responseContent);
            ms.Position = 0;
            await ms.CopyToAsync(originalResponseStream);
            context.Response.Body = originalResponseStream;

        }
        private async Task<string> GetResponseContentAsync(HttpResponse response)
        {
            //response.Body.Seek(0, SeekOrigin.Begin);
            var content = await new StreamReader(response.Body).ReadToEndAsync();
            //response.Body.Seek(0, SeekOrigin.Begin);
            return content;
        }
        private string ModifyResponseContent(string content)
        {
            // 在这里实现你的响应内容修改逻辑
            return content;
        }
    }
}
