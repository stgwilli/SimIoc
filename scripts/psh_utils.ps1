function exit_if_not_on_master() {
  $status = git status

  if (! $status[0].endswith("master"))
  {
    "You need to run this on a master branch"
    exit
  }
}
