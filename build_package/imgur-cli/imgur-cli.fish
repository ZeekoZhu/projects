set -l cmd imgur-cli

function __fish_imgur_cli_no_subcommand --description 'Test if imgur-cli has yet to be given the subcommand'
    for i in (commandline -opc)
        if contains -- $i auth config delete upload
            return 1
        end
    end
    return 0
end

complete -c $cmd -n __fish_imgur_cli_no_subcommand -a auth -d 'Authenticate imgur-cli'
complete -c $cmd -n __fish_imgur_cli_no_subcommand -a config -d 'Configure imgur-cli'
complete -c $cmd -n __fish_imgur_cli_no_subcommand -a delete -d 'Delete an image'
complete -c $cmd -n __fish_imgur_cli_no_subcommand -a upload -d 'Upload an image'

complete -c $cmd -n '__fish_seen_subcommand_from auth' -s c -l client-id -d 'Client ID'
complete -c $cmd -n '__fish_seen_subcommand_from auth' -s s -l client-secret -d 'Client Secret'

complete -c $cmd -n '__fish_seen_subcommand_from config' -a set-default-album -d 'Set default album'

complete -c $cmd -n '__fish_seen_subcommand_from upload' -l stdin -d 'Read the image from stdin'
complete -c $cmd -n '__fish_seen_subcommand_from upload' -s f -l file -d 'The image file to upload'
complete -c $cmd -n '__fish_seen_subcommand_from upload' -s t -l title -d 'The title of the image'
complete -c $cmd -n '__fish_seen_subcommand_from upload' -s n -l name -d 'The name of the file'
complete -c $cmd -n '__fish_seen_subcommand_from upload' -s d -l description -d 'The description of the image'
complete -c $cmd -n '__fish_seen_subcommand_from upload' -s a -l album -d 'The album id to add the image to'


complete -c $cmd -s h -l help -d 'Display this help and exit'
complete -c $cmd -s v -l version -d 'Display version information and exit'
