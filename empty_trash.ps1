$shell = New-Object -ComObject Shell.Application
$recycle_bin = $shell.Namespace(0xA)

$recycle_bin.items() | %{ remove-item $_.path -Recurse -Confirm:$false}
