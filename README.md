# Healthcare Speech-to-Text Pipeline

Demonstração de transcrição médica com análise semântica usando Azure Cognitive Services.

## Demo Online
https://[seu-usuario].github.io/healthcare-stt-demo/

## Funcionalidades
- 🎤 Gravação de áudio em tempo real
- 📊 Visualização de ondas sonoras
- 🧠 Análise semântica com IA
- ⚡ Interface moderna com animações
- 📱 Totalmente responsivo

## Para demonstração offline
Abra o console do navegador (F12) e execute:
```javascript
mockDemo()

### Passo 3: Fazer upload via GitHub Web
1. Após criar o repositório, clique em "uploading an existing file"
2. Arraste os arquivos `index.html` e `README.md`
3. Commit com mensagem "Initial demo"

### Passo 4: Ativar GitHub Pages
1. Vá em Settings → Pages
2. Source: Deploy from a branch
3. Branch: main / root
4. Save

**Em 2 minutos seu site estará online!** 🚀

## 2. Conectar com a API Azure (Opcional)

### Configurar CORS no Azure Function
```bash
az functionapp cors add \
  --name healthspeechpipeline \
  --resource-group health.health \
  --allowed-origins https://[seu-usuario].github.io
Atualizar API Endpoint no Frontend
No arquivo index.html, linha ~402:
javascriptconst API_ENDPOINT = 'https://healthspeechpipeline.azurewebsites.net/api';