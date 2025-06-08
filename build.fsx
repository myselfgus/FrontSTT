#r "paket:
nuget Fake.Core.Target
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Tools.Git
//"

open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.Tools

// Configurações gerais
let buildDir = "./build/"
let srcDir = "./src/"
let testDir = "./tests/"
let artifactsDir = "./artifacts/"

// Função para logar mensagens
let log message =
    Trace.log message

// Definindo os targets
Target.create "Clean" (fun _ ->
    log "Limpando diretórios de build e artefatos..."
    Shell.cleanDirs [buildDir; artifactsDir]
)

Target.create "Restore" (fun _ ->
    log "Restaurando dependências..."
    DotNet.restore id srcDir
)

Target.create "Build" (fun _ ->
    log "Compilando o projeto..."
    DotNet.build (fun opts ->
        { opts with
            Configuration = DotNet.BuildConfiguration.Release }) srcDir
)

Target.create "Test" (fun _ ->
    log "Executando os testes..."
    DotNet.test (fun opts ->
        { opts with
            Configuration = DotNet.BuildConfiguration.Release }) testDir
)

Target.create "Package" (fun _ ->
    log "Gerando pacotes e artefatos..."
    Shell.mkdir artifactsDir
    Shell.copyDir buildDir artifactsDir
)

Target.create "All" ignore

// Sequência de execução
"Clean"
  ==> "Restore"
  ==> "Build"
  ==> "Test"
  ==> "Package"
  ==> "All"

// Executa o script com 'All' como padrão
Target.runOrDefault "All"