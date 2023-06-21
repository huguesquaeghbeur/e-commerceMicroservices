namespace User.API.Controllers
{
    [EnableCors("specialOrigin")]
    [Route("api/v1/client")]
    public class ClientController : Controller
    {
        private readonly IClientRepository<Client> _clientRepository;
        private readonly ClientDataContext _clientContext;
        private readonly LoginService _loginService;

        public ClientController(IClientRepository<Client> clientRepository, ClientDataContext clientContext, LoginService loginService)
        {
            _clientRepository = clientRepository;
            _clientContext = clientContext;
            _loginService = loginService;
        }

        [Authorize(Policy = "admin")]
        [HttpGet]
        public async Task<ActionResult> GetAllClients()
        {
            return Ok(await _clientRepository.GetClients());
        }

        [Authorize(Policy = "admin")]
        [HttpGet("{userName}")]
        public async Task<ActionResult> GetClient(string userName)
        {
            return Ok(await _clientRepository.GetClientByName(userName));
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string userName, [FromForm] string password)
        {
            string token = _loginService.GenerateToken(userName, password);
            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return NotFound();
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> Signin([FromForm] string userName, [FromForm] string password, [FromForm] string email, [FromForm] bool isAdmin)
        {
            Client client = new()
            {
                UserName = userName,
                Password = password,
                Email = email,
                IsAdmin = isAdmin
            };

            await _clientRepository.CreateClient(client);
            if (_clientContext.SaveChanges() > 0)
            {
                return Ok(new { Message = "Erreur" });
            }
            string token = _loginService.GenerateToken(client.UserName, client.Password);
            if (token != null)
            {
                return Ok(new { Client = client, Token = token });
            }
            return NotFound();
        }

        [Authorize(Policy = "admin")]
        [HttpPut("{userName}")]
        public async Task<IActionResult> PutClient(string userName, [FromForm] Client newClient)
        {
            Client client = await _clientContext.Clients.FirstOrDefaultAsync(c => c.UserName == userName);
            if (client != null)
            {
                client.UserName = newClient.UserName ?? client.UserName;
                client.Password = newClient.Password ?? client.Password;
                client.Email = newClient.Email ?? client.Email;
                client.IsAdmin = newClient.IsAdmin;

                if (_clientContext.SaveChanges() > 0)
                {
                    return Ok(new { Message = "Client mis à jour" });
                }
                return Ok(new { Message = "Erreur" });
            }
            return NotFound();
        }

        [Authorize(Policy = "admin")]
        [HttpDelete("{userName}")]
        public async Task<IActionResult> RemoveClient(string userName)
        {
            Client client = await _clientContext.Clients.FirstOrDefaultAsync(c => c.UserName == userName);
            if (client != null)
            {
                _clientContext.Remove(client);
                if (_clientContext.SaveChanges() > 0)
                {
                    return Ok(new { Message = "Client supprimé" });
                }
                return Ok(new { Message = "Erreur" });
            }
            return NotFound();   
        }
    }
}




