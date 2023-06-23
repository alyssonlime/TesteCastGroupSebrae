using API.Model;

namespace API.Interface
{
    public interface ICEPService
    {
        Task<ViaCepEndereco> ConsultarAsync(string cep);
    }
}
