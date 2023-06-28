using OneOf;
using OneOf.Types;
using Unilake.Worker.Contracts;
using Unilake.Worker.Contracts.Requests.Git;
using Unilake.Worker.Contracts.Responses.Git;
using Unilake.Worker.Services.Git;

namespace Unilake.Worker.Events.Git.Types;

public class GitPushTaskEvent : GitTaskEvent
{
    public string Remote { get; set; }
    public string Branch { get; set; }

    public static implicit operator GitPushTaskEvent(GitPushRequest request) => new()
    {
        Branch = request.Branch,
        Remote = request.Remote
    };

    protected override OneOf<Success<IRequestResponse>, Error<string>> Handle(IGitService gitService)
    {
        return gitService.Push(Remote, Branch)
            .Match<OneOf<Success<IRequestResponse>, Error<string>>>(
                _ => new Success<IRequestResponse>(new GitActionResultResponse()
                {
                    Message = "Successfully pushed changes to remote repository",
                    ProcessReferenceId = ProcessReferenceId
                }),
                e => new Error<string>(e.Value.Message.FirstToUpper())
            );
    }
}
