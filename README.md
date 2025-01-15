# Integer Compressor

.NET 9.0 Command-Line Tool capable of reading a CSV file containing integers, outputting encoded/decoded representations based on command-line input

# Steps to Clone

1. Clone the repository
2. Using a command line interface navigate to the root \IntegerCompressor folder (change directories) and
3. Execute the following command: "dotnet build" 
- this will build the cloned application.

# Encode command

To Encode a CSV File, using a command line interface navigate to the internal \IntegerCompressor folder, i.e. \IntegerCompressor\IntegerCompressor (change directories) and execute the following command: 
"dotnet run encode path-to-csv-file" 
- Replace the path-to-csv-file with the actual path of the csv you wish to encode

For example purposes: the root IntegerCompressor has an integers.csv file, to execute the encode command, run the following using a command line interface after navigating to the internal \IntegerCompressor folder;
"dotnet run encode ..\integers.csv" (if using windows command prompt)

# Decode/Decodefile commands

To Decode an Encoded String, using a command line interface navigate to the internal \IntegerCompressor folder (as above), and execute the following command: 
"dotnet run decode encoded-string" 
- Replace the encoded-string with the actual encoded string to decode

Note:- Certain command line interfaces only allow for a fixed number of characters, that can be "typed"/"pasted" (i.e. windows command prompt allows 8191 characters, including all commands), the larger the number of integers to encode, the larger the encoded representation will be. In this case, I would recommend creating a text file and placing the encoded string within, then running the following alternative;
"dotnet run decodefile path-to-text-file"
- Replace the path-to-text-file with the actual path of the text file to decode

For example purposes: the root IntegerCompressor has an encoded.txt file, to execute the decodefile command, run the following using a command line interface after navigating to the internal \IntegerCompressor folder;
"dotnet run decodefile ..\encoded.txt" (if using windows command prompt)
