using Backend.Models;

namespace Backend.Services;

public class Service
{
    public object GetLandingData(LandingModel model)
    {
        //use model
        return new
        {
            message = "Hello from Service"
        };
    }
}