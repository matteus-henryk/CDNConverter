using CDNConverter.API.Domain.Interfaces.UseCases;
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
        [HttpGet("CDN")]
        [Produces(typeof(List<ResponseOriginalLogJson>))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        public IActionResult GetAllOriginalSavedLogs([FromServices] IGetAllOriginalLogsUseCase service)
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
        [HttpGet("CDN/{id}")]
        [Produces(typeof(ResponseOriginalLogJson))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOriginalLogById([FromServices] IGetOriginalLogByIdUseCase service, [FromRoute] Guid id)
        {
            var result = await service.ExecuteAsync(id);

            if (result == null)
                return NotFound(ResourceResponseMessages.NOTFOUND_LOG);

            return Ok(result);
        }

        /// <summary>
        /// Salva um log "MINHA CDN" no diretorio raiz e base dados 
        /// </summary>
        /// <param name="file">Arquivo .txt no formato "MINHA CDN"</param>
        /// <returns>Retorna os dados do log "MINHA CDN" salvo na base</returns>
        [HttpPost("CDN")]
        [Produces(typeof(ResponseOriginalLogJson))]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SaveOriginalLog([FromServices] ICreateOriginalLogUseCase service, IFormFile file)
        {
            var result = await service.ExecuteAsync(file);

            return Created(string.Empty, result);
        }

        /// <summary>
        /// Busca todos os logs "MINHA CDN" no diretorio 
        /// </summary>
        /// <returns>Retorna um arquivo zip com todos os arquivos .txt</returns>
        [HttpGet("CDN/file")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllOriginalSavedLogsFiles([FromServices] IGetAllOriginalLogsFileZipUseCase service)
        {
            var result = await service.ExecuteAsync();

            if (result == null) 
                return NotFound(ResourceResponseMessages.NOTFOUND_LOGS);

            return File(result, "application/zip", $"OriginalsLogs{DateTime.UtcNow.Date.ToString("dd/MM/yyyy")}.zip");
        }

        /// <summary>
        /// Busca um log "MINHA CDN" no diretorio por identificador
        /// </summary>
        /// <param name="id">Identificador "MINHA CDN"</param>
        /// <returns>Retorna um arquivo .txt de log "MINHA CDN"</returns>
        [HttpGet("CDN/file/{id}")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetOriginalSavedLogFileById([FromServices] IGetOriginalLogFileByIdUseCase service, [FromRoute] Guid id)
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
        [HttpPost("AGORA")]
        [Produces(typeof(ResponseConvertedLogJson))]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConvertOriginalLogByFile([FromServices] IConvertOriginalLogByFileUseCase service, IFormFile file)
        {
            var result = await service.ExecuteAsync(file);

            return Created(string.Empty, result);
        }

        /// <summary>
        /// Converte um log no formato "MINHA CDN" para "AGORA" usando um identificador de um log "MINHA CDN" na base
        /// </summary>
        /// <param name="id">Identificador "MINHA CDN"</param>
        /// <returns>Retorna as informações da base do log "AGORA"</returns>
        [HttpPost("AGORA/{id}")]
        [Produces(typeof(ResponseConvertedLogJson))]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConvertOriginalLogById([FromServices] IConvertOriginalLogByIdUseCase service, [FromRoute] Guid id)
        {
            var result = await service.ExecuteAsync(id);

            return Created(string.Empty, result);
        }

        /// <summary>
        /// Converte um log no formato "MINHA CDN" para "AGORA" salva na base e diretorio
        /// </summary>
        /// <param name="file">Arquivo .txt no formato "MINHA CDN"</param>
        /// <returns>Retorna um arquivo .txt do log "AGORA"</returns>
        [HttpPost("AGORA/file")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConvertOriginalLogByFileReturn([FromServices] IConvertOriginalLogByFileReturnUseCase service, IFormFile file)
        {
            var result = await service.ExecuteAsync(file);

            return File(result.ConvertedLogFile, "text/plain", $"{result.Id}_Converted.txt");
        }

        /// <summary>
        /// Converte um log no formato "MINHA CDN" para "AGORA" salva na base e diretorio atravez de identificador de log "MINHA CDN"
        /// </summary>
        /// <param name="id">Identificador "MINHA CDN"</param>
        /// <returns>Retorna um arquivo .txt do log "AGORA"</returns>
        [HttpPost("AGORA/file/{id}")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ConvertOriginalLogByIdFileReturn([FromServices] IConvertOriginalLogByIdFileReturnUseCase service, [FromRoute] Guid id)
        {
            var result = await service.ExecuteAsync(id);

            return File(result.ConvertedLogFile, "text/plain", $"{result.Id}_Converted.txt");
        }

        /// <summary>
        /// Busca um log "AGORA" no diretorio por identificador
        /// </summary>
        /// <param name="id">Identificador "AGORA"</param>
        /// <returns>Retorna um arquivo .txt de log "AGORA"</returns>
        [HttpGet("AGORA/file/{id}")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetConvertedSavedLogFileById([FromServices] IGetConvertedLogFileByIdUseCase service, [FromRoute] Guid id)
        {
            var result = await service.ExecuteAsync(id);

            if (result == null)
                return NotFound(ResourceResponseMessages.NOTFOUND_LOG);

            return File(result, "text/plain", $"{id}_Converted.txt");
        }

        /// <summary>
        /// Busca todos os arquivos do diretorio no formato "AGORA"
        /// </summary>
        /// <returns>Retorna um arquivo zip de logs "AGORA"</returns>
        [HttpGet("AGORA/file")]
        [Produces(typeof(byte[]))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllConvertedSavedLogsFiles([FromServices] IGetAllConvertedLogsFilesUseCase service)
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
        [HttpGet("AGORA")]
        [Produces(typeof(IList<ResponseConvertedLogJson>))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        public IActionResult GetAllConvertedAndOriginalLog([FromServices] IGetAllConvertedAndOriginalLogsUseCase service)
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
        [HttpGet("AGORA/{id}")]
        [Produces(typeof(ResponseConvertedLogJson))]
        [ProducesResponseType(typeof(NotFoundObjectResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BadRequestObjectResult), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetConvertedAndOriginalLogById([FromServices] IGetConvertedAndOriginalLogByIdUseCase service, [FromRoute] Guid id)
        {
            var result = await service.ExecuteAsync(id);

            if (result == null) 
                return NotFound(ResourceResponseMessages.NOTFOUND_LOG);

            return Ok(result);
        }

        #endregion
    }
}
