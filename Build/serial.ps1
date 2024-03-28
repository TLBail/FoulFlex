# Si le script fait rien, executer dans une console powershell (win + r > powershell): 
# Set-ExecutionPolicy Unrestricted -Scope CurrentUser -Force 

# Define WMI query
$serialPorts = Get-WmiObject -Class Win32_SerialPort

# Select properties
$selectedProperties = $serialPorts | Select-Object -Property Name, DeviceID, Description

# Extract DeviceID
$deviceIDs = $selectedProperties | ForEach-Object { $_.DeviceID }

# Output to file
$filePath = ".\Build\Foulflex_Data\StreamingAssets\port.txt"
$deviceIDs | Out-File -FilePath $filePath
