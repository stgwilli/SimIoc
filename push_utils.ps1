function commit_and_push_to_remote()
{
  $message = read-host

  git add -A
  git commit -m $message
  git push origin master
}


commit_and_push_to_remote
