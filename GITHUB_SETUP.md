# 📤 Guia: Como Subir o Projeto para GitHub

## ✅ O que você precisa

1. Uma conta no [GitHub](https://github.com) (crie se não tiver)
2. Git instalado no seu computador ([Download Git](https://git-scm.com))
3. Credenciais configuradas (ou token de autenticação)

---

## 📋 Passo a Passo

### **Passo 1: Criar um repositório no GitHub**

1. Acesse [github.com](https://github.com)
2. Clique no **`+`** no canto superior direito
3. Selecione **"New repository"**
4. Preencha os dados:
   - **Repository name**: `CleanArchitecture` (ou o nome que quiser)
   - **Description**: "API REST com Clean Architecture para gestão de usuários"
   - **Public** ou **Private** (escolha sua preferência)
   - ⚠️ **NÃO** selecione "Initialize this repository with a README" (você já tem um)
5. Clique em **"Create repository"**

**Você receberá uma URL como essa:**
```
https://github.com/seu-usuario/CleanArchitecture.git
```

---

### **Passo 2: Configurar Git Localmente**

Execute os comandos abaixo no PowerShell (na pasta do projeto):

#### Configurar identidade (se for a primeira vez):
```powershell
git config --global user.name "Seu Nome"
git config --global user.email "seu-email@gmail.com"
```

#### Inicializar o repositório Git:
```powershell
cd "C:\Users\Guilherme Jeunon\Desktop\Projetos\CleanArchitecture"
git init
```

#### Adicionar o repositório remoto:
```powershell
git remote add origin https://github.com/seu-usuario/CleanArchitecture.git
```

⚠️ **Substitua `seu-usuario` pelo seu usuário do GitHub!**

---

### **Passo 3: Fazer o Commit Inicial**

#### Adicionar todos os arquivos:
```powershell
git add .
```

#### Verificar arquivos a commitar:
```powershell
git status
```

#### Fazer o commit:
```powershell
git commit -m "Initial commit: Clean Architecture API com endpoints CRUD"
```

---

### **Passo 4: Fazer Push para o GitHub**

#### Fazer push para a branch main:
```powershell
git branch -M main
git push -u origin main
```

⚠️ **Você pode ser solicitado a autenticar:**
- Se usar HTTPS: Digite seu username e password (ou token)
- Se usar SSH: Precisa configurar uma chave SSH antes

---

### **Passo 5: Verificar no GitHub**

1. Acesse `https://github.com/seu-usuario/CleanArchitecture`
2. Verifique se todos os arquivos foram enviados
3. Seu README.md será exibido como a página principal do repositório

---

## 🔐 Autenticação no GitHub (HTTPS vs SSH)

### **Opção 1: HTTPS (Mais fácil)**
- Usa username + token (recomendado)
- Menos configuração

**Gerar um Personal Access Token:**
1. GitHub → Settings → Developer settings → Personal access tokens → Tokens (classic)
2. Clique em "Generate new token (classic)"
3. Selecione escopos: `repo`
4. Copie o token gerado
5. Use o token como senha quando solicitado

### **Opção 2: SSH (Mais seguro)**
- Requer configuração inicial
- Chaves públicas/privadas

**Gerar chave SSH (se não tiver):**
```powershell
ssh-keygen -t ed25519 -C "seu-email@gmail.com"
```

Depois adicione a chave pública no GitHub:
- GitHub → Settings → SSH and GPG keys → New SSH key

---

## 📝 Comandos Git Úteis Futuros

Após o primeiro push, você usará estes comandos regularmente:

```powershell
# Ver status do repositório
git status

# Adicionar mudanças
git add .

# Fazer commit
git commit -m "Descrição das mudanças"

# Fazer push (enviar para GitHub)
git push

# Puxar atualizações do repositório remoto
git pull

# Ver histórico de commits
git log

# Criar uma nova branch
git checkout -b feature/nova-feature

# Mudar de branch
git checkout main
```

---

## 🛠️ Configurar GitHub Desktop (Alternativa Gráfica)

Se preferir uma interface gráfica em vez da linha de comando:

1. Baixe [GitHub Desktop](https://desktop.github.com)
2. Faça login com sua conta GitHub
3. File → Clone repository
4. Selecione o repositório que criou
5. Clone para sua pasta local
6. Depois arraste seus arquivos para a pasta clonada

---

## ✨ Exemplo Completo (Linha de Comando)

Aqui está um fluxo completo resumido:

```powershell
# 1. Configurar identidade (primeira vez apenas)
git config --global user.name "Seu Nome"
git config --global user.email "seu-email@gmail.com"

# 2. Navegar para o projeto
cd "C:\Users\Guilherme Jeunon\Desktop\Projetos\CleanArchitecture"

# 3. Inicializar repositório
git init

# 4. Adicionar remoto (substitua seu-usuario)
git remote add origin https://github.com/seu-usuario/CleanArchitecture.git

# 5. Adicionar arquivos
git add .

# 6. Fazer commit
git commit -m "Initial commit: Clean Architecture API"

# 7. Renomear branch e fazer push
git branch -M main
git push -u origin main

# Insira seu username + token quando solicitado
```

---

## ❓ Solução de Problemas

### **Erro: "fatal: remote origin already exists"**
```powershell
git remote remove origin
git remote add origin https://github.com/seu-usuario/CleanArchitecture.git
```

### **Erro: "Permission denied (publickey)"** (SSH)
Verifique se sua chave SSH está configurada corretamente no GitHub.

### **Erro: "Authentication failed"** (HTTPS)
Use um Personal Access Token em vez de senha. Gere um em GitHub → Settings → Developer settings.

---

## 🎉 Pronto!

Seu projeto agora está no GitHub! Você pode:
- Compartilhar o link do repositório
- Colaborar com outros
- Usar para portfólio
- Implementar CI/CD com GitHub Actions

**Boa sorte! 🚀**

