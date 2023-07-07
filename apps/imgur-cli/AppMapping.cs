using AutoMapper;
using Imgur.API.Models;
using Zeeko.ImgurCli.Service;

namespace Zeeko.ImgurCli;

public class AppMapping : Profile
{
  public AppMapping()
  {
    CreateMap<OAuth2Token, AppAuthToken>().ReverseMap();
  }
}
