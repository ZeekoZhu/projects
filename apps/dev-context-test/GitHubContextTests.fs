module Projects.DevContext.Test.GitHubContextTests

open FsToolkit.ErrorHandling
open NUnit.Framework
open Projects.DevContext.ContextProviders
open FsUnitTyped

module GetOwnerRepoFromUrl =
  type TestData =
    { Url: string
      Expected: Validation<string * string, exn> }

  let testData url expected = { Url = url; Expected = expected }

  let ``protocol cases``: TestData list =
    [
      // ssh
      (testData "git@github.com:owner/repo.git" (Validation.ok ("owner", "repo")))
      // https
      (testData "https://github.com/owner/repo.git" (Validation.ok ("owner", "repo")))
      // git protocol
      (testData "git://github.com/owner/repo.git" (Validation.ok ("owner", "repo")))
      // https without .git
      (testData "https://github.com/owner/repo" (Validation.ok ("owner", "repo")))
      ]

  [<TestCaseSource(nameof ``protocol cases``)>]
  let ``different protocols`` (td: TestData) =
    let path = GitHubUtils.getOwnerRepoFromUrl td.Url
    path |> shouldEqual td.Expected


  let ``invalid url cases`` =
    [
      // invalid url
      "hello world" ]

  let inline shouldBeError (r: Validation<'a, _>) =
    match r with
    | Ok it -> Assert.Fail $"Expected error, but got: %A{it}"
    | Error _ -> ()

  [<TestCaseSource(nameof ``invalid url cases``)>]
  let ``invalid url`` (url: string) =
    let path = GitHubUtils.getOwnerRepoFromUrl url
    path |> shouldBeError
