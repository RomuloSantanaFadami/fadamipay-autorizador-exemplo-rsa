# fadamipay-autorizador-exemplo-rsa
Código exemplificando como trabalhar com chave privada e publica para criptografia RSA PKCS nº 1.

## Exemplos de uso para teste:

O seguinte comando pode ser executado no arquivo gerado após build:

```
Criptografia.RSA.Test.exe -k -v "Texto que quero criptografar"
```

No console veremos o seguinte retorno:

![image](https://user-images.githubusercontent.com/61064057/127758356-b95a4905-6396-4f51-a816-2c8b93b9ad32.png)


## Comandos disponíveis:

```
  -v, --valor           (Default: Esse texto será usado como exemplo de criptografia) Valor a ser criptografado para teste

  -k, --gerar-chaves    (Default: false) Informativo se deve criar chave privada e publica

  -p, --path-chaves     (Default: Keys) Path onde será disponibilizado/lido chaves privadas e publicas

  --help                Display this help screen.

  --version             Display version information.
```
