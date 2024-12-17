using CDNConverter.API.Domain.Interfaces.Services;
using CDNConverter.API.Shared.Comunication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CDNConverter.API.Controllers
{
    [Route("CDNConverter/")]
    [ApiController]
    public class LogsController : ControllerBase
    {

        #region Original Log

        /// <summary>
        /// Busca todos os logs "MINHA CDN"
        /// </summary>
        /// <returns>Retorna uma lista de logs "MINHA CDN"</returns>
        [HttpGet("")]
        [Produces(typeof(List<ResponseOriginalLogJson>))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        public IActionResult GetAllOriginalSavedLogs([FromServices] IGetAllOriginalLogsService service)
        {
            var result = service.Execute();

            if (result == null) 
                return NotFound(ResourceResponseMessages.NOTFOUND_LOGS);

            return Ok(result);
        }

        /// <summary>
        /// Busca um log "MINHA CDN" por identificador unico
        /// </summary>
        /// <param name="id">Identificador "MINHA CDN"</param>
        /// <returns>Retorna um log "MINHA CDN"</returns>
        [HttpGet("{id}")]
        [Produces(typeof(ResponseOriginalLogJson))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOriginalLogById([FromServices] IGetOriginalLogByIdService service, [FromRoute] Guid id)
        {
            var result = await service.ExecuteAsync(id);

            if (result == null)
                return NotFound(ResourceResponseMessages.NOTFOUND_LOG);

            return Ok(result);
        }

        /// <summary>
        /// Cria um log "MINHA CDN" no diretorio raiz e base dados 
        /// </summary>
        /// <param name="file">Arquivo .txt no formato "MINHA CDN"</param>
        /// <returns>Retorna os dados do log "MINHA CDN" salvo na base</returns>
        [HttpPost("")]
        [Produces(typeof(ResponseOriginalLogJson))]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SaveOriginalLog([FromServices] ICreateOriginalLogService service, IFormFile file)
        {
            var result = await service.ExecuteAsync(file);

            return Created(string.Empty, result);
        }

        /// <summary>
        /// Busca todos os logs "MINHA CDN" no diretorio 
        /// </summary>
        /// <returns>Retorna um arquivo zip com todos os arquivos .txt</returns>
        [HttpGet("file")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllOriginalSavedLogsFiles([FromServices] IGetAllOriginalLogsFileZipService service)
        {
            var result = await service.ExecuteAsync();

            if (result == null) 
                return NotFound(ResourceResponseMessages.NOTFOUND_LOGS);

            return File(result, "application/zip", $"OriginalsLogs{DateTime.UtcNow.Date.ToString("dd/MM/yyyy")}.zip");
        }

        /// <summary>
        /// Busca um log "MINHA CDN" no diretorio por identificado
        /// </summary>
        /// <param name="id">Identificador "MINHA CDN"</param>
        /// <returns>Retorna um arquivo .txt de log "MINHA CDN"</returns>
        [HttpGet("file/{id}")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOriginalSavedLogFileById([FromServices] IGetOriginalLogFileByIdService service, [FromRoute] Guid id)
        {
            var result = await service.ExecuteAsync(id);

            if (result == null) 
                return NotFound(ResourceResponseMessages.NOTFOUND_LOG);

            return File(result, "text/plain", $"{id}_Original.txt");
        }

        #endregion

        #region Converted Log

        /// <summary>
        /// Converte um log no formato "MINHA CDN" para "AGORA" salva na base e diretorio
        /// </summary>
        /// <param name="file">Arquivo .txt no formato "MINHA CDN"</param>
        /// <returns>Retorna as informações da base do log "AGORA "</returns>
        [HttpPost("convert")]
        [Produces(typeof(ResponseConvertedLogJson))]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConvertOriginalLogByFile([FromServices] IConvertOriginalLogByFileService service, IFormFile file)
        {
            var result = await service.ExecuteAsync(file);

            return Created(string.Empty, result);
        }

        /// <summary>
        /// Converte um log no formato "MINHA CDN" para "AGORA" usando um identificador na base de um log "MINHA CDN"
        /// </summary>
        /// <param name="id">Identificador "MINHA CDN"</param>
        /// <returns>Retorna as informações da base do log "AGORA"</returns>
        [HttpPost("convert/{id}")]
        [Produces(typeof(ResponseConvertedLogJson))]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConvertOriginalLogById([FromServices] IConvertOriginalLogByIdService service, [FromRoute] Guid id)
        {
            var result = await service.ExecuteAsync(id);

            return Created(string.Empty, result);
        }

        /// <summary>
        /// Converte um log no formato "MINHA CDN" para "AGORA" salva na base e diretorio
        /// </summary>
        /// <param name="file">Arquivo .txt no formato "MINHA CDN"</param>
        /// <returns>Retorna um arquivo .txt do log "AGORA"</returns>
        [HttpPost("convert/file")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConvertOriginalLogByFileReturn([FromServices] IConvertOriginalLogByFileReturnService service, IFormFile file)
        {
            var result = await service.ExecuteAsync(file);

            return File(result.ConvertedLogFile, "text/plain", $"{result.Id}_Converted.txt");
        }

        /// <summary>
        /// Converte um log no formato "MINHA CDN" para "AGORA" salva na base e diretorio atravez de identificador de log "MINHA CDN"
        /// </summary>
        /// <param name="id">Identificador "MINHA CDN"</param>
        /// <returns>Retorna um arquivo .txt do log "AGORA"</returns>
        [HttpPost("convert/file/{id}")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConvertOriginalLogByIdFileReturn([FromServices] IConvertOriginalLogByIdFileReturnService service, [FromRoute] Guid id)
        {
            var result = await service.ExecuteAsync(id);

            return File(result.ConvertedLogFile, "text/plain", $"{result.Id}_Converted.txt");
        }

        /// <summary>
        /// Busca todos os arquivos do diretorio no formato "AGORA"
        /// </summary>
        /// <returns>Retorna um arquivo zip de logs "AGORA"</returns>
        [HttpGet("convert/file")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllConvertedSavedLogsFiles([FromServices] IGetAllConvertedLogsFilesService service)
        {
            var result = await service.ExecuteAsync();

            if (result == null) 
                return NotFound(ResourceResponseMessages.NOTFOUND_LOGS);

            return File(result, "application/zip", $"ConvertedLogs{DateTime.UtcNow.Date.ToString("dd/MM/yyyy")}.zip");
        }

        /// <summary>
        /// Busca todos os logs da base no formato "AGORA"
        /// </summary>
        /// <returns>Retorna uma lista de logs "AGORA"</returns>
        [HttpGet("convert")]
        [Produces(typeof(IList<ResponseConvertedLogJson>))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        public IActionResult GetAllConvertedAndOriginalLog([FromServices] IGetAllConvertedAndOriginalLogsService service)
        {
            var result = service.Execute();

            if (result == null) return NotFound(ResourceResponseMessages.NOTFOUND_LOGS);

            return Ok(result);
        }

        /// <summary>
        /// Busca o log no formato "AGORA" e o "MINHA CDN" por identificador "AGORA"
        /// </summary>
        /// <param name="id">Identificador "AGORA"</param>
        /// <returns>Retorna um log "AGORA" e "MINHA CDN"</returns>
        [HttpGet("convert/{id}")]
        [Produces(typeof(ResponseConvertedLogJson))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetConvertedAndOriginalLogById([FromServices] IGetConvertedAndOriginalLogByIdService service, [FromRoute] Guid id)
        {
            var result = await service.ExecuteAsync(id);

            if (result == null) 
                return NotFound(ResourceResponseMessages.NOTFOUND_LOG);

            return Ok(result);
        }

        #endregion
    }
}
