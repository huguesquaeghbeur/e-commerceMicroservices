namespace User.API.Controllers
{
    [EnableCors("allConnections")]
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
        [HttpGet("{email}")]
        public async Task<ActionResult> GetClient(string email)
        {
            return Ok(await _clientRepository.GetClientByEmail(email));
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromForm] string email, [FromForm] string password)
        {
            string token = _loginService.GenerateToken(email, password);
            if (token != null)
            {
                return Ok(new { Token = token });
            }
            return NotFound();
        }

        [Route("signin")]
        [HttpPost]
        public async Task<IActionResult> Signin([FromForm] string firstName, [FromForm] string lastName, [FromForm] string password, [FromForm] string email, [FromForm] bool isAdmin)
        {
            Client client = new()
            {
                FirstName = firstName,
                LastName = lastName,
                Password = password,
                Email = email,
                IsAdmin = isAdmin
            };

            await _clientRepository.CreateClient(client);
            if (_clientContext.SaveChanges() > 0)
            {
                return Ok(new { Message = "Erreur" });
            }
            string token = _loginService.GenerateToken(client.Email, client.Password);
            if (token != null)
            {
                return Ok(new { Client = client, Token = token });
            }
            return NotFound(new { Message = "ça à foirè" });
        }



        [Authorize(Policy = "admin")]
        [HttpPut("{email}")]
        public async Task<IActionResult> PutClient(string email, [FromForm] Client newClient)
        {
            Client client = await _clientContext.Clients.FirstOrDefaultAsync(c => c.Email == email);
            if (client != null)
            {
                client.FirstName = newClient.FirstName ?? client.FirstName;
                client.LastName = newClient.LastName ?? client.LastName;
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
        [HttpDelete("{email}")]
        public async Task<IActionResult> RemoveClient(string email)
        {
            Client client = await _clientContext.Clients.FirstOrDefaultAsync(c => c.Email == email);
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




