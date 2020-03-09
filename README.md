# TestePratico
TestePratico Microserviços

- rodar o projeto
- com o sql managment studio se conectar ao 127.0.0.1,5433
- rodar o script de dados iniciales

1) EXPLIQUE COM SUAS PALAVRAS O QUE É DOMAIN DRIVEN DESIGN E SUA IMPORTÂNCIA
NA ESTRATÉGIA DE DESENVOLVIMENTO DE SOFTWARE.

    Resposta: O Domain Design Driven é um padrão de desenvolvimento com foco no dominio (modelos) e com foco na lógica do negocio, a importância de utilizar esse padrão é porque implementa os conceptos de SOLID permitindo um desenvolvimento de alta coesão e baixo acoplamento.

2) EXPLIQUE COM SUAS PALAVRAS O QUE É E COMO FUNCIONA UMA ARQUITETURA BASEADA
EM MICROSERVICES. EXPLIQUE GANHOS COM ESTE MODELO E DESAFIOS EM SUA
IMPLEMENTAÇÃO.

    Resposta: Os Microservices dividem as funcionalidades em serviços independentes, permitindo sua distribuiçao entre servidores, clientes, e outros serviços, melhorando a capacidade de escalado pra uma funcionalidade em especial e permitindo replicar se for nessesario.

3) EXPLIQUE QUAL A DIFERENÇA ENTRE COMUNICAÇÃO SINCRONA E ASSINCRONA E QUAL O
MELHOR CENÁRIO PARA UTILIZAR UMA OU OUTRA.

    Resposta: A comunicação Sincrona espera uma resposta do servidor ou remitente, parando tudo o processamento, uma comunicação assincrona envia uma solicitude ao servidor ou remitente e quando chegar a resposta continua as funciones ligadas à comunicação assincrona sem parar o processamento, o melhor cenário para utilizar uma comunicação assincrona é quando tiver que se comunicar com um servidor do que não se sabe sua disponibilidade nem o tempo de resposta, a comunicação sincrona é melhor utilizado em ambientes de alta disponibilidade e comunicação imediata.