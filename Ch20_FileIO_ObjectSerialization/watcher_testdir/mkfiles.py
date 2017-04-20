#! python3
import os

for i in range(42):
    with open(str.format("test_file_{}.txt",i),'w') as f:
        f.write(str.format("This is a test file #{} for the DirectoryWatcher C# App",i))
