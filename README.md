# BinReveal
> A forensic project for detecting file signatures in a file.

<b>Build status: </b><span style="color: white; background: green;">Beta</span>


## Installation

Windows:

```
Move the file into C:\Windows\System32\
* Requires Administrator rights
```

## Usage

Ex: binreveal.exe C:\Windows\System32\Shell32.dll --hexdump

Arguments:

```
[file] (The path to the file you want to examine)
--hexdump (Dumps the first 100 bytes in hexadecimal from the file specified).
```

## Development setup

Clone this repository into your visual studio projects directory.


## Release History
* 1.0
  * Added intial project with example signatures
  
## FAQ

* Will there be a Linux release of this project?

Yes in the future there will be a Linux version written in Java as well.

## Meta

Developer: Sem Voigtländer
Distributed under the MIT General Public license. See ``LICENSE`` for more information.

## Contributing

1. Fork it (<https://github.com/MTJailed/BinReveal/fork>)
2. Create your feature branch (`git checkout -b feature/fooBar`)
3. Commit your changes (`git commit -am 'Add some fooBar'`)
4. Push to the branch (`git push origin feature/fooBar`)
5. Create a new Pull Request
