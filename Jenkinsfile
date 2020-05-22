pipeline {
    agent any 
    stages {
        /*stage('Build') {
            agent {
                dockerfile {
                    filename 'Dockerfile'
                    additionalBuildArgs '-t birdwatcherclient --no-cache'                    }
                }
            steps {
                echo "Building inside a nginx-container"
                sh "docker run --name myangular -p 80:80 -d birdwatcherclient"
            }
        }*/
        stage('Deploy') {
            agent any
            steps {
                sh '/usr/local/bin/docker-compose up --build'
            }
        }
        /*stage ('Deploy') {
            agent {
                docker {
                    image 'birdwatcherclient'
                    args '-p 80:80 --name myangular -d'
                }
            }
            steps {
                echo "Spinning up birdwatcherclient"
            }
        }*/
    } 
}