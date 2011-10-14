function exit_if_remote_exists($remote_name) {
  $branch_list = git branch
  foreach($branch in $branch_list){
    if ($branch.Contains($remote_name)) {
      "Remote already exists"
      exit
    }
  }
}

"Remote Name"
$remote_name = read-host

exit_if_remote_exists($remote_name)

git checkout -b $remote_name
git push origin $remote_name
"Created Remote " + $remote_name
