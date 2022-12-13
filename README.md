<h1 align="center">Tryitter</h1>

<p align="center">Esse repositório foi criado para o desenvolvimento do back end do desafio final da aceleração ministrada pela Trybe em parceria com a XP Inc. </p>

<p align="center">
  <a href="#Explicação do projeto">Explicação do projeto</a> •
  <a href="#Swagger">Swagger</a> •
  <a href="#Deploy">Deploy</a> •
  <a href="#Primeiros passos">Primeiros passos</a> •
  <a href="#Autores">Autores</a> 
</p>

---

## Explicação do projeto

A Trybe decidiu desenvolver sua própria rede social, totalmente baseada em texto de até 300 caracteres. O objetivo é proporcionar um ambiente em que as pessoas estudantes poderão, por meio de textos e imagens, compartilhar suas experiências e também acessar posts que possam contribuir para seu aprendizado.💚


---

## Swagger :bookmark_tabs:

A documentação da API está disponivel através do

```bash
https://localhost:7140/swagger/index.html
```

---

## Deploy

A aplicação está disponivel através desse [link](https://tryitter-blm-group.azurewebsites.net/)

---

## Primeiros passos

Faça o clone do repositório utilizando o comando abaixo

```bash
git clone git@github.com:MarianeAlgayer/tryitter.git
```

Entrar no diretório da aplicação

```bash
cd tryitter
cd src
```

Instale as dependências

```bash
dotnet restore
```

Implemente o banco de dados

```bash
dotnet ef database update
```

Rode a aplicação

```bash
dotnet run
```

---

## Autores

- [@byancaknorst](https://www.github.com/byancaknorst)
- [@marianealgayer](https://github.com/MarianeAlgayer)
- [@lazarokabib](https://github.com/fontanez123)
