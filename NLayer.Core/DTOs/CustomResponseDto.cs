using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        //static factory desing 
        // design patternlarin olayi ,nesne uretme olayini clientlardan almak ve ayri bir classta olusturmak
        public T Data { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public List<String> Errors { get; set; }

        public static CustomResponseDto<T> Success(int StatusCode, T data)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode, Data = data };
        }
        public static CustomResponseDto<T> Success(int StatusCode)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode };
        }

        public static CustomResponseDto<T> Fail(int StatusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode, Errors = errors };
        }
        public static CustomResponseDto<T> Fail(int StatusCode, string errors)
        {
            return new CustomResponseDto<T> { StatusCode = StatusCode, Errors = new List<string> { errors } };
        }
    }
}
