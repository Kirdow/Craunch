# Craunch
Allows for storing your launch parameters on disk in encrypted format, requiring a password when launching, in cases where sensitive data is carried via USB.

## Is this safe?
Yes and no. Mostly no, but with the way it's intended to be used, yes. It uses AES for encrypting the launch arguments, including which file to launch. However, this only protects it from programs which scans every device plugged into their computer. If you were to launch the app and enter the password, you're still vulnerable to key loggers and process explorers, as launch parameters shows up there. As always, if they manage to get their hands on your encrypted file, nothing stops them from brute forcing an attack on the file.

## How do I use it?
If you use it, please make sure you read the previous point, and understand that it doesn't make you immune when you use the file, only when it's idle, and even then it's not making you immune either.

That said, if you haven't used it in the current folder, just launch it, and the setup should start. If there is already a craunch.dat in the current directory, it will try to launch it and ask for password. In that case, if you want to make a new one, either delete craunch.dat or start the app using ``Craunch.exe -setup``.

## How does it work?
Pretty simple, you enter the path and command line arguments, with options for both x64 and x86. You also enter a master password which will encrypt the data onto a file. It's using AES encryption which should be similar to what most services use nowdays. Whenever you enter the password, it decrypts the .dat file and execute the entry that matches your systems architecture.

## Can I use the code?
Yes, feel free to use the code found here in your own implementations, and modify it to your liking.
