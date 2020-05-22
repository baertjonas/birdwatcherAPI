pipeline {
    agent any 
    stages {
        stage('Build') {
            agent {
                dockerfile {
                    filename 'Dockerfile'
                    additionalBuildArgs '-t birdwatcherclient --no-cache'                    }
                }
            steps {
                echo "Building inside a nginx-container"
            }
        }
        stage ('Deploy') {
            agent {
                docker {
                    image 'birdwatcherclient'
                    args '-p 80:80 --name myangular -d'
                }
            }
            steps {
                echo "Spinning up birdwatcherclient"
            }
        }
    } 
}