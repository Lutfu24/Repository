using System.Net;

namespace Repository.DTOs.Common;

public record ResponseDto(HttpStatusCode StatusCode, string Message);
