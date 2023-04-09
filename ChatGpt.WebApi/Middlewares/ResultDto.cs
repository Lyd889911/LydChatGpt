namespace ChatGpt.WebApi.Middlewares
{
    public record ResultDto(int Code,string? Message,object? Data);
}
