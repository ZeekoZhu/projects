module Projects.Blogkit.AspNetCoreInterop
  let inline (~~) x =
    ((^a or ^b): (static member op_Implicit: ^a -> ^b) x)


