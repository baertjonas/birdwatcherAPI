pipeline {
    agent any {
        stages {
            stage('Build') {
                agent {
                    dockerfile {
                        filename 'Dockerfile'
                        additionalBuildArgs '-t birdwatcherclient --no-cache'
                    }
                }
                steps { "Building inside a nginx-container"}
            }
        }
    } 
}