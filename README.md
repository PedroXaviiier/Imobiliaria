# Imobiliaria

### História de John Wick e sua Imobiliária em Lages

---

**Cenário:**

John Wick, depois de uma longa carreira em Nova York, decidiu se estabelecer em Lages, uma cidade tranquila e charmosa no sul do Brasil. Com uma vista para as montanhas e um clima acolhedor, Lages parecia o lugar perfeito para começar de novo. Ao caminhar pelas ruas históricas da cidade, John percebeu o potencial do mercado imobiliário local e decidiu abrir uma imobiliária. Assim nasceu a **Wick Realty Lages**, uma empresa focada em imóveis de alto padrão e em proporcionar um serviço personalizado para seus clientes.

Para garantir que sua imobiliária fosse um sucesso, John precisava de um sistema de gestão moderno e eficiente. Ele queria algo que fosse tão bem organizado quanto ele, sem espaço para erros ou dados desnecessários. Ele convocou sua equipe de desenvolvedores e explicou sua visão para o sistema:

“Precisamos de um sistema que garanta a precisão e a integridade dos dados. Cada imóvel deve ter um corretor responsável e um cliente como dono. Além disso, não quero dados duplicados. Se um cliente já está registrado ou um imóvel já foi cadastrado, o sistema deve alertar sobre isso. E mais, quero que meus corretores possam entrar em contato com clientes que favoritaram imóveis que eles gerenciam, para que possamos ser proativos na prospecção.”

---

### Requisitos Funcionais do Sistema de Gestão da Wick Realty Lages

1. **Gestão de Imóveis**:
   - **Cadastro de Imóveis**: O sistema deve permitir o cadastro de novos imóveis, incluindo detalhes como endereço, tipo (casa, apartamento, terreno), área em metros quadrados, valor de venda ou locação, e uma descrição detalhada. Além disso, é obrigatório que cada imóvel tenha um corretor responsável e um cliente como dono. Esses campos não podem ser deixados em branco.
   - **Edição e Exclusão de Imóveis**: A equipe precisa editar os detalhes de imóveis existentes e excluir aqueles que não estão mais disponíveis. Durante a edição, o sistema deve verificar se há duplicação de informações, como endereços já cadastrados.
   - **Visualização de Imóveis**: Deve ser possível visualizar uma lista de imóveis com filtros por tipo, valor, localização e disponibilidade. A lista deve indicar claramente o corretor responsável por cada imóvel.
   - **Upload de Fotos**: Cada imóvel deve ter a opção de upload de fotos, permitindo que os clientes vejam detalhes visuais dos imóveis.
   - **Controle de Duplicação**: Ao cadastrar um imóvel, o sistema deve verificar se já existe um imóvel com o mesmo endereço ou descrição. Em caso afirmativo, deve alertar o usuário e impedir o cadastro duplicado.

2. **Gestão de Clientes**:
   - **Cadastro de Clientes**: O sistema deve permitir o cadastro de clientes com informações como nome, CPF (único), telefone, e-mail e suas preferências de imóvel. O CPF deve ser único e obrigatório.
   - **Edição e Exclusão de Clientes**: A equipe deve poder atualizar as informações dos clientes e remover registros quando necessário. O sistema deve garantir que não haja CPFs duplicados.
   - **Histórico de Interações**: Cada cliente deve ter um histórico de interações, incluindo imóveis visualizados e contatos feitos.

3. **Gestão de Corretores**:
   - **Cadastro de Corretores**: Deve ser possível cadastrar corretores, incluindo nome, CPF (único), registro CRECI, telefone e e-mail. Cada corretor será responsável por um conjunto de imóveis, e o sistema deve impedir CPFs ou CRECIs duplicados.
   - **Atribuição de Imóveis**: Corretores precisam ser atribuídos a imóveis específicos. Um imóvel não pode ser cadastrado sem um corretor responsável. A aplicação deve permitir que os gestores da imobiliária atribuam ou reatribuam corretores a imóveis conforme necessário.
   - **Prospecção de Imóveis**: Corretores devem ter acesso à lista de clientes que favoritaram imóveis sob sua gestão. Eles podem entrar em contato diretamente com esses clientes para discutir mais detalhes e potencialmente fechar negócios.

4. **Perfil de Cliente**:
   - **Visualização de Imóveis Disponíveis**: Clientes logados podem visualizar uma lista de imóveis disponíveis para venda ou locação, com filtros por tipo, valor, localização e outros critérios relevantes.
   - **Detalhes do Imóvel**: Clientes podem acessar uma página de detalhes do imóvel, que inclui uma descrição completa, fotos, preço, e dados de contato do corretor responsável.
   - **Favoritar Imóveis**: Clientes podem marcar imóveis como favoritos. A lista de imóveis favoritos é acessível no perfil do cliente e será usada pelos corretores para prospecção.
   - **Entrar em Contato**: Os clientes podem enviar mensagens diretamente aos corretores a partir da página de detalhes do imóvel, solicitando mais informações ou agendando visitas.

5. **Segurança e Autenticação**:
   - **Autenticação de Usuários**: O sistema deve incluir um mecanismo de login seguro para corretores e clientes. Somente usuários autenticados podem acessar funcionalidades sensíveis.
   - **Controle de Acesso**: Deve haver diferentes níveis de acesso para garantir que corretores possam gerenciar seus imóveis e clientes, enquanto os clientes só têm acesso às funcionalidades de visualização e contato.

6. **Relatórios e Análises**:
   - **Relatórios de Vendas e Locação**: John quer relatórios que mostrem o desempenho da imobiliária, incluindo número de vendas e locações por período, e desempenho de cada corretor.
   - **Análise de Preferências de Clientes**: O sistema deve gerar análises sobre as preferências dos clientes, como tipos de imóveis mais procurados, faixas de preço e localizações mais populares.

7. **Perfil Anonimo**:

   - Visualizar 5 imoveis recentes.
   - Espaço para criação de usuario.

### Tecnologias Utilizadas
- **Backend**: ASP.NET Core, C#
- **Frontend**: ASP.NET MVC, HTML, CSS
- **Banco de Dados**: SQL Server
- **ORM**: Entity Framework Core
- **Autenticação**: Iremos construir nossa própria autenticação por cookie

### Estrutura em Camadas (N-layer)
1. **Camada de Apresentação (Presentation Layer)**:
   - Responsável pela interface do usuário, utilizando  MVC Views, interage com a camada de dominio.
   
2. **Camada de Domínio (Domain Layer)**:

   - Contém a lógica de negócio e os serviços, como validações e regras específicas
   - Modelos de domínio e regras de negócios centrais.

3. **Camada de acceso a dados DAO(Data Access Object) **:
   - Interação com o banco de dados através do Entity Framework Core.
	
4. **Testes**
   
  - Local para realizar testes da solução, unitario, integração e automação.
  - Iremos usar xunit 

5. **Docs**

  - Pasta de documentação, como scripts de banco

Comando para gerar modelos de classe baseado nas tabelas.

  dotnet ef dbcontext scaffold "Server=XAVIER\SQLEXPRESS01;Database=ImobiliariaDB;Integrated Security=true;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer 