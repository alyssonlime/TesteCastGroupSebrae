using API.Model;

namespace API.Interface.Service
{
    public interface ICEPService
    {
        Task<ViaCepEndereco> ConsultarAsync(string cep);
    }
}
