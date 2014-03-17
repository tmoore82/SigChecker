SigChecker
=========

Checks a file signature against an expected signature. Returns a boolean.

Takes the following inputs:
- filepath = location of file (string)
- signatureSize = length (in bytes) you expect the signature to be (integer)
- offset = the byte offset, if any, from the start of the file where the signature should be (integer)
- expectedSignature = the hexadecimal set you expect to find (string)

## Example

Say you are going to extract the files from a compressed folder. Before you try, you want to verify it's a zip file and of a type you can extract with your available resources (i.e., if you don't have 7-zip installed, you can't extract the files). 

    if(SigChecker.SigChecker.CheckSignature(@"C:\users\%username%\desktop\testfile.zip", 4, 0, "50-4B-03-04"))
	{
	    // Extract files
	}
	else
	{
		throw new ArgumentException("Not a recognized zip format.");
	}