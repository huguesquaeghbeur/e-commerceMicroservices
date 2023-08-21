namespace User.API.Services
{
    public class LoginService
    {
        private readonly IClientRepository<Client> _clientRepository;
        
        public LoginService(IClientRepository<Client> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public string GenerateToken(string email, string password)
        {
            //Verification dans la base de données de l'email et mot de passe
            Client c = _clientRepository.SearchOne(c => c.Email == email && c.Password == password);
            if (c != null)
            {
                //Données à stocker dans le token
                List<Claim> claims = new()
                {
                    new Claim(ClaimTypes.Name, c.FirstName),
                    new Claim(ClaimTypes.Email, c.Email ),
                    new Claim(ClaimTypes.Role, "admin"),
                };
                //Objet pour signer le token
                SigningCredentials signingCredentials = new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("azerty123:superSecure")),
                    SecurityAlgorithms.HmacSha256);

                //Créer notre jwt
                JwtSecurityToken jwt = new(issuer: "hugs@2023", audience: "hugs@2023", claims: claims, signingCredentials: signingCredentials, expires: DateTime.Now.AddDays(1));
                return new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            return null;
        }
    }
}
