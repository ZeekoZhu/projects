module Projects.DevContext.Test.GitLabContextTests

open NUnit.Framework
open Projects.DevContext.ContextProviders
open FsUnitTyped
open GitLabUtils


module GetNamespacedPath =

  [<Test>]
  let ``ssh protocol`` () =
      let path = getNamespacedPath "git@gitlab.com:test/test.git"
      path |> shouldEqual "test/test"

  [<Test>]
  let ``http protocol`` () =
      let path = getNamespacedPath "http://gitlab.com/test/test.git"
      path |> shouldEqual "test/test"

  [<Test>]
  let ``deep nested project`` () =
    let path = getNamespacedPath "http://gitlab.com/deep/nested/project/test.git"
    path |> shouldEqual "deep/nested/project/test"
