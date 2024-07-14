node('DOTNETNODEJS') {
    stage('SCM') {
        checkout([$class: 'GitSCM', branches: [[name: '*/master']], doGenerateSubmoduleConfigurations: false, extensions: [], subModuleCfg: [], userRemoteConfigs: [[url: 'https://github.com/pvlucban/sample-net8-authentication']]])
    }
    stage('Build') {
        sh: 'dotnet build WebApplication1'
    }
    stage('Test') {
        echo 'Run tests'
    }
    stage('Publish') {
        echo 'Build docker and push'
    }
    stage('Deploy') {
        echo 'Deploy to kubernetes'
    }
    stage('Archive') {
        archiveArtifacts artifacts: 'WebApplication1/*.*'
    }
}