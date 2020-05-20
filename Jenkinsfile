pipeline {
    agent {
        dockerfile {
            filename 'Dockerfile'
            additionalBuildArgs '-t birdwatcherclient --no-cache'
        }
    }
    stages {
        stage('Build') {
            steps {
                echo "Building..."
            }
        }
    }    
}