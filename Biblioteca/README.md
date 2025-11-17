Projeto: Sistema de Biblioteca em Arquitetura de Microsserviços


– Documentos de Requisitos (Resumo para README)

1. Propósito do sistema

Construir o back-end de um sistema de biblioteca utilizando arquitetura de microsserviços (.NET Web API + SQLite). O sistema permitirá cadastrar e consultar livros, cadastrar membros, controlar empréstimos e devoluções, e demonstrar integrações entre microsserviços (duas buscas entre serviços e uma alteração de dados enviada de um serviço para outro).

2. Usuários





3. Estrutura geral dos microsserviços


Microsserviços e Função 

books-service > Gerencia livros e disponibilidade
members-service > Gerencia membros (usuários da biblioteca)
loans-service > Controla empréstimos e devoluções


4. Integrações entre microsserviços 

Integração 1 — Busca simples A

Origem: loans-service
Destino: books-service

Objetivo: Quando o usuário faz um empréstimo, o loans-service precisa verificar se o livro existe e se há cópias disponíveis.





Integração 2 — Busca simples B 


Origem: loans-service
Destino: members-service

Objetivo: Antes de emprestar um livro, o sistema precisa validar se o membro está ativo e se ainda pode pegar mais livros.




Integração 3 — Alteração de dados entre serviços


Origem: loans-service
Destino: books-service e/ou members-service

Objetivo: Após confirmar o empréstimo, o loans-service altera dados em outro serviço (requisito obrigatório).

Cenário principal:

Ao confirmar o empréstimo:

O loans-service cria um registro local (INSERT INTO Loans).
Em seguida, faz uma requisição: PATCH (para diminuir as cópias em 1)

E opcionalmente chama:
Somar 1 no contador de empréstimos ativos do membro; 

Resultado:

O livro agora tem uma cópia a menos disponível.
O membro tem um empréstimo ativo a mais.
