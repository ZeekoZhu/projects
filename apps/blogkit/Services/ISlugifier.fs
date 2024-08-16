namespace Projects.Blogkit.Services

open System.Threading.Tasks

type ISlugifier =
  abstract Slugify : string -> Task<string>
