. .\psh_utils.ps1

"Remote to Delete"
$remote_name = read-host

exit_if_not_on_master

git branch -D $remote_name
git push origin :$remote_name
