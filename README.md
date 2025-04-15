# Passo a passo da criação de uma API

## 1. Criar a Interface (Contrato - Definição dos métodos que o Repository terá)
  Criar uma interface respectiva a model (tabela/entidade do Banco de dados). A interface deve conter os métodos que serão implementados no Repository, que são baseados no CRUD (Criar, Ler, Atualizar e Deletar).
  
## 2. Criar o Repository (Responsável pela comunicação com o banco de dados)
  O repository irá herdar a Interface e implementará os métodos, agora especificando o que cada método realizará. Criar a variável Contexto e injetar o Contexto (Banco de dados da API), 
  já que é função do Repository se comunicar com o banco de dados.
    
## 3. Configurar a Injeção de dependência
  No arquivo 'Program.CS', iremos informar ao C# quando ele deve criar os objetos relacionados ao meu Repository.
  Ex: builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();

## 4. Criar o Controller (Recebe e responde requisições)
  No Controller é onde é definido o Endpoint dessa entidade. 
  (Injetar o Repository) - Criar uma variável privada, do tipo da sua respectiva Interface, após isso, criar método construtor que recebe como parâmetro um tipo Repository e 
  atribuir esse parâmetro a variável. Ex: variavelInterface = variavelRepository
  Após isso, serão definidos os métodos que irão tratar as requisições recebidas (Get, Post, Put, Delete)
  
